import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {
  groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

  expensesDto:services.ExpensesDTO;
  expensesDtoDetails:services.ExpensesDTO[];
  expensesDtoList:services.ExpensesDTO[]=[];

  payersExpensesDto:services.Payers_ExpensesDTO;
  payersExpensesDetails:services.Payers_ExpensesDTO[];

  payeesExpensesDto:services.Payees_ExpensesDTO;
  payeesExpensesDetails:services.Payees_ExpensesDTO[];

public pageTitle:string;
GroupId:number;
check:boolean=false;
arr:number[]=[];
  constructor(private route:ActivatedRoute,private groupsServices:services.GroupsClient,
    private expenseServices:services.ExpensesClient,private payeeServices:services.PayeesExpensesClient,
    private payerServices:services.PayersExpensesClient) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
this.GroupId=id;

    this.groupsServices.getGroup2(id).subscribe({
      next:groupDto=>{
        console.log(groupDto);
        this.pageTitle=groupDto.groupName;
        console.log(this.pageTitle);

      }
    });

    this.expenseServices.expenseForAGroup(id).subscribe({
      next:expenseDto=>{
        console.log(expenseDto);
        this.expensesDtoDetails=expenseDto;
        if(this.expensesDtoDetails.length==0){
          console.log("No Expense Found");
        }

      }
    });
  }

}
