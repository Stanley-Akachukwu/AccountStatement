import { Component, OnInit } from '@angular/core';
import { AccountStatement } from '../models/accountstatement';
import { AccountstatementService } from '../services/accountstatement.service';
@Component({
  selector: 'app-accountstatement',
  templateUrl: './accountstatement.component.html',
  styleUrls: ['./accountstatement.component.css']
})
export class AccountstatementComponent implements OnInit {
  public accountStatements: AccountStatement[] = [];
  haSaccountStatements: boolean=false;
  statementRequestModel: any = {
    startdate: new Date(),
    enddate: new Date()
  };

  constructor(private statementService: AccountstatementService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    if (this.statementRequestModel.startdate > this.statementRequestModel.enddate) {
      alert("Invalid date selected!")
    }
    else {
      this.statementService.getStatements(this.statementRequestModel).subscribe(result => {
        this.accountStatements = result;
        this.haSaccountStatements = true;
       console.log(this.accountStatements);
      }, error => console.error(error));
      this.reset();

    }
  }

  reset(): void {
    this.statementRequestModel.startdate = new Date();
    this.statementRequestModel.enddate = new Date();
  }
  //getWeather() {
  //  this.http.get(this._baseUrl + 'api/statements/GetWether')
  //    .pipe(
  //      map((res: any) => res.json())
  //    );
  //}
}
