using Microsoft.AspNetCore.Mvc;
using System.IO;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace AzureBootCamp.Controllers
{
    public class RegistrationController : Controller
    {
        // Uncomment to enable registration logic
        /*
        [HttpPost]
        public async Task<IActionResult> RegisterExcel(string Name, string Email, string Company, string Role)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "registrations.xlsx");
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = fileInfo.Exists ? new ExcelPackage(fileInfo) : new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Count > 0 ? package.Workbook.Worksheets[0] : package.Workbook.Worksheets.Add("Registrations");
                int row = worksheet.Dimension?.Rows + 1 ?? 1;
                if (row == 1)
                {
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Email";
                    worksheet.Cells[1, 3].Value = "Company";
                    worksheet.Cells[1, 4].Value = "Role";
                }
                worksheet.Cells[row, 1].Value = Name;
                worksheet.Cells[row, 2].Value = Email;
                worksheet.Cells[row, 3].Value = Company;
                worksheet.Cells[row, 4].Value = Role;
                package.SaveAs(fileInfo);
            }
            return RedirectToAction("Index", "Home");
        }
        */
    }
}
