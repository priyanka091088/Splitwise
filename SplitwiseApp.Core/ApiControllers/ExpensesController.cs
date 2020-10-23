using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using System.Threading.Tasks;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Group;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class ExpensesController: ControllerBase
    {
        private readonly IExpenses _expenses;
        private readonly IGroups _groups;
        public ExpensesController(IExpenses expenses, IGroups groups)
        {
            _expenses = expenses;
            _groups = groups;

        }

        // GET: api/Expenses/id
        [HttpGet("{id}")]
        [Route("expense")]
        public async Task<ActionResult<ExpensesDTO>> GetExpenseByExpenseId(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                ExpensesDTO expensesDto = await _expenses.GetExpensesById(id);
                return Ok(expensesDto);
            }
            return NotFound();

        }

        [HttpGet]
        [Route("groupsExpense")]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> ExpenseForAGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                IEnumerable<ExpensesDTO> expensesDto = await _expenses.GetExpenseForGroup(groupId);
                return Ok(expensesDto);
            }
            return NotFound();
        }

        // POST: api/Expenses
        [HttpPost]
        public IActionResult AddExpense(Expenses expenses)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _expenses.AddAnExpense(expenses);
            return Ok();
        }

        // PUT: api/Expenses
        [HttpPut]
        public IActionResult UpdateExpense(Expenses expenses)
        {
            if (_expenses.ExpenseExist(expenses.expenseId))
            {

                _expenses.UpdateAParticularExpense(expenses);
                return Ok();
            }
            return NotFound();

        }

        // DELETE: api/Expenses
        [HttpDelete]
        public IActionResult DeleteExpense(int expenseId)
        {
            if (_expenses.ExpenseExist(expenseId))
            {
                _expenses.DeleteAnExpense(expenseId);
                return Ok();
            }
            return NotFound();
        }
    }
}
