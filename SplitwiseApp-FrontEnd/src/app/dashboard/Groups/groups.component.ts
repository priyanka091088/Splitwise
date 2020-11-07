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
check:boolean=false;
arr:number[]=[];
  constructor(private route:ActivatedRoute,private groupsServices:services.GroupsClient,
    private expenseServices:services.ExpensesClient,private payeeServices:services.PayeesExpensesClient,
    private payerServices:services.PayersExpensesClient) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    //this.groupDto=this.initializeGroupDto();
    this.groupsServices.getGroup2(id).subscribe({
      next:groupDto=>{
        console.log(groupDto);
        this.pageTitle=groupDto.groupName;
        console.log(this.pageTitle);
        //this.groupDtoDetails.push(groupDto);
      }
    });

    this.expenseServices.expenseForAGroup(id).subscribe({
      next:expenseDto=>{
        console.log(expenseDto);
        this.expensesDtoDetails=expenseDto;
        alert(this.expensesDtoDetails[0].expenseId)
      }
    });
  }
  ShowAndHide(id:number){
if(this.arr[id]!=-1){
 // this.check=!this.check;
 this.arr.splice(this.arr.indexOf(id), 1);
}
else{
  this.arr.push(id);
  //this.arr[id]=id;
  //this.check=false;
}
this.payeeServices.getPayeesExpensesById(id).subscribe({
  next:payee=>{
    console.log(payee);
    this.payeesExpensesDetails=payee;

  }
});
this.payerServices.getPayersExpensesByexpenseId(id).subscribe({
  next:payer=>{
    console.log(payer);
this.payersExpensesDetails=payer;
  }
})
  }
private initializeGroupDto(){
  return{
    groupId:0,
    groupName:"",
    groupType:""
  }
}
}
