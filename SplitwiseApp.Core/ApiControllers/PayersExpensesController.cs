using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Payers_Expense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class PayersExpensesController: ControllerBase
    {
        private readonly IPayersExpenses _payersExpense;
        public PayersExpensesController(IPayersExpenses payersExpense)
        {
            _payersExpense = payersExpense;
        }

        [HttpGet("{id}")]
        public IActionResult GetPayersExpenses(int id)
        {

             _payersExpense.GetPayersExpenses(id);
            return Ok();
        }
    }
}
