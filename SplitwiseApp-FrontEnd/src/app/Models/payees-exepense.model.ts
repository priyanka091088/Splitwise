import { Expense } from './expense.model';
import { User } from './user.model';

export interface PayeesExpenses{
  pId :number;
  Share :number;
  expenseId :number;
  payerId :string;
  receiverId :string;
  expenses :Expense;
  payer :User;
  receiever :User;
}
