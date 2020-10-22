using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Payees_Expenses;
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
        public async Task<ActionResult<Payees_ExpensesDTO>> GetPayeesExpenses(int id)
        {

            Payees_ExpensesDTO expenseDtos = await _payeesExpense.GetPayeesExpenses(id);
            return Ok(expenseDtos);
        }
    }
}
