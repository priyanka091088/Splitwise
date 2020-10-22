using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expenses;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class ExpensesController: ControllerBase
    {
        private readonly IExpenses _expenses;
        public ExpensesController(IExpenses expenses)
        {
            _expenses = expenses;

        }

        // GET: api/Expenses/id
        [HttpGet("{id}")]
        [Route("expense")]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> GetExpense(int id)
        {

            IEnumerable<ExpensesDTO> expensesDto = await _expenses.GetExpenseForGroup(id);
            return Ok(expensesDto);
        }

        [HttpGet]
        [Route("groupsExpense")]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> ExpenseForAGroup(int groupId)
        {

            IEnumerable<ExpensesDTO> expensesDto = await _expenses.GetExpenseForGroup(groupId);
            return Ok(expensesDto);
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<ExpensesDTO>> AddAGroup(ExpensesDTO expenses)
        {

            ExpensesDTO addExpense = await _expenses.AddAnExpense(expenses);
            return Ok(addExpense);
        }

        // PUT: api/Expenses
        [HttpPut]
        public async Task<ActionResult<ExpensesDTO>> UpdateExpense(ExpensesDTO expenses)
        {

            ExpensesDTO updateExpense = await _expenses.UpdateAParticularExpense(expenses);
            return Ok(updateExpense);
        }

        // DELETE: api/Expenses
        [HttpDelete]
        public async Task<ActionResult<ExpensesDTO>> DeleteExpense(int expenseId)
        {

            ExpensesDTO deleteExpense = await _expenses.DeleteAnExpense(expenseId);
            return Ok(deleteExpense);
        }
    }
}
