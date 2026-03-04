using IT6CFirstWebAppCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace IT6CFirstWebAppCS.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var model = new SettingsViewModel();

            // Non-generic way to get enum values and names
            ArrayList items = new ArrayList();
            foreach (var value in Enum.GetValues(typeof(WorkPreference)))
            {
                items.Add(new
                {
                    Id = (int)value,
                    Name = Enum.GetName(typeof(WorkPreference), value)
                });
            }

            model.PreferenceList = new SelectList(items, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SettingsViewModel model)
        {
            // Store individual values in TempData without serialization
            TempData["UserPreference"] = (int)model.SelectedPreference;
            TempData["UserPreference2"] = (int)model.SelectedPreference2;

            // Convert array to a simple comma-separated string for transport
            if (model.SelectedRoles != null)
            {
                TempData["UserRoles"] = string.Join(",", model.SelectedRoles);
            }

            return RedirectToAction("Details");
        }

        [HttpGet]
        public IActionResult Details()
        {
            // Retrieve simple types from TempData
            if (TempData["UserPreference"] == null) return RedirectToAction("Index");

            var model = new SettingsViewModel();

            // Cast the integer back to the Enum
            model.SelectedPreference = (WorkPreference)TempData["UserPreference"];
            model.SelectedPreference2 = (WorkPreference)TempData["UserPreference2"];

            // Split the string back into a basic array
            string roles = TempData["UserRoles"] as string;
            if (!string.IsNullOrEmpty(roles))
            {
                model.SelectedRoles = roles.Split(',');
            }

            return View(model);
        }
    }
}

