import { Expense } from './expense.model';
import { User } from './user.model';

export interface PayersExpenses{
  Id :number;
  paidAmount  :number;
  Share :number;
  expenseId :number;
  payerId :string;
  expenses :Expense;
  payer :User;
}
