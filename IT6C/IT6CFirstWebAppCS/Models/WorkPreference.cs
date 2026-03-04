using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IT6CFirstWebAppCS.Models
{
    public enum WorkPreference
    {
        [Display(Name = "Remote Work")]
        Remote = 1,
        [Display(Name = "On-Site")]
        OnSite = 2,
        [Display(Name = "Hybrid Model")]
        Hybrid = 3
    }

    public class SettingsViewModel
    {
        public WorkPreference SelectedPreference { get; set; }
        public WorkPreference SelectedPreference2 { get; set; }

        // Use a string array or int array for multiple selections to avoid List<T> generics if preferred
        public string[] SelectedRoles { get; set; }

        // A non-generic list for the dropdown
        public SelectList PreferenceList { get; set; }

    }
}
