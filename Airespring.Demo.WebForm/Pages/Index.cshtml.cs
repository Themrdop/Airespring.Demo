using Airespring.Demo.Interfaces;
using Airespring.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Airespring.Demo.WebForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IEmployeeProvider _employeeProvider;

        public IEnumerable<Employee> employee;

        public IndexModel(ILogger<IndexModel> logger, IEmployeeProvider employeeProvider)
        {
            _logger = logger;
            _employeeProvider = employeeProvider;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            this.employee = await _employeeProvider.GetEmployees(cancellationToken);
        }

        public async Task<IActionResult> OnPost([FromForm] Employee employee, CancellationToken cancellationToken)
        {
            await _employeeProvider.InsertEmployee(employee, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}