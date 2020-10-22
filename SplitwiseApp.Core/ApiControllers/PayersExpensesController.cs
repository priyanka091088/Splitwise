using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Payers_Expenses;
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
        public async Task<ActionResult<Payers_ExpensesDTO>> GetPayersExpenses(int id)
        {

            Payers_ExpensesDTO expenseDtos = await _payersExpense.GetPayersExpenses(id);
            return Ok(expenseDtos);
        }
    }
}
