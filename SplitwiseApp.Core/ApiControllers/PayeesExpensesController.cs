using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Payees_Expense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class PayeesExpensesController:ControllerBase
    {
        private readonly IPayeeExpenses _payeesExpense;
        public PayeesExpensesController(IPayeeExpenses payeesExpense)
        {
            _payeesExpense = payeesExpense;
        }

        [HttpGet("{id}")]
        public IActionResult GetPayeesExpenses(int id)
        {

             _payeesExpense.GetPayeesExpenses(id);
            return Ok();
        }
    }
}
