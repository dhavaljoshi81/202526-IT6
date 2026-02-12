using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections;
using IT6OrderManagementWebAppCS.Models;

namespace IT6OrderManagementWebAppCS.Controllers
{
    public class ProductController : Controller
    {

        private string _connectionString;
        private IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = 
                _configuration.GetConnectionString("IT6OrderManagementDB");
        }
        

        public IActionResult Index()
        {
            ArrayList products = GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = GetProductById(id);
            if (product.ProductId == 0) return NotFound();
            return View(product);
        }

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            if (newProduct == null)
            {
                newProduct = new Product();
                ViewBag.Error = "Please fill all required fields";
                return View(newProduct);
            }

            if (string.IsNullOrEmpty(newProduct.ProductName))
                newProduct.ProductName = "";

            if (newProduct.ProductName == "" || newProduct.Price <= 0)
            {
                ViewBag.Error = "Please enter valid Product Name and Price > 0";
                return View(newProduct);
            }

            AddProduct(newProduct);
            TempData["Message"] = "Product added successfully!";
            return RedirectToAction("Index");
        }

        private ArrayList GetAllProducts()
        {
            ArrayList products = new ArrayList();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product p = new Product();
                            p.ProductId = reader.GetInt32(0);
                            p.ProductName = reader.GetString(1);
                            p.Price = reader.GetDecimal(2);
                            p.InStock = reader.GetBoolean(3);
                            p.CreatedDate = reader.IsDBNull(4) ? "" : reader.GetDateTime(4).ToString("dd/MM/yyyy");
                            products.Add(p);
                        }
                    }
                }
            }
            return products;
        }

        private Product GetProductById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product p = new Product();
                            p.ProductId = reader.GetInt32(0);
                            p.ProductName = reader.GetString(1);
                            p.Price = reader.GetDecimal(2);
                            p.InStock = reader.GetBoolean(3);
                            p.CreatedDate = reader.IsDBNull(4) ? "" : reader.GetDateTime(4).ToString("dd/MM/yyyy");
                            return p;
                        }
                    }
                }
            }
            return new Product();
        }

        private void AddProduct(Product newProduct)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", newProduct.ProductName);
                    cmd.Parameters.AddWithValue("@Price", newProduct.Price);
                    cmd.Parameters.AddWithValue("@InStock", newProduct.InStock);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // GET: Edit Product
        public IActionResult Edit(int id)
        {
            Product p = GetProductById(id);
            if (p.ProductId == 0)
            {
                TempData["Message"] = "Product not found!";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // POST: Update Product
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (updatedProduct == null || updatedProduct.ProductId == 0)
            {
                TempData["Message"] = "Invalid product data";
                return RedirectToAction("Index");
            }

            if (updatedProduct.ProductName == "" || updatedProduct.Price <= 0)
            {
                ViewBag.Error = "Please enter valid Product Name and Price";
                return View(updatedProduct);
            }

            UpdateProduct(updatedProduct);
            TempData["Message"] = "Product updated successfully!";
            return RedirectToAction("Index");
        }

        // GET: Delete Confirmation
        public IActionResult Delete(int id)
        {
            Product p = GetProductById(id);
            if (p.ProductId == 0)
            {
                TempData["Message"] = "Product not found!";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // POST: Delete Product
        [HttpPost]
        public IActionResult Delete(Product p)
        {
            if (p.ProductId > 0)
            {
                DeleteProduct(p.ProductId);
                TempData["Message"] = "Product deleted successfully!";
            }
            else
            {
                TempData["Message"] = "Delete failed!";
            }
            return RedirectToAction("Index");
        }

        // NEW Methods for Database
        private void UpdateProduct(Product updatedProduct)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", updatedProduct.ProductId);
                    cmd.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                    cmd.Parameters.AddWithValue("@Price", updatedProduct.Price);
                    cmd.Parameters.AddWithValue("@InStock", updatedProduct.InStock);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
