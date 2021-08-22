import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { OperationResult } from '../../models/operation-result';


@Component({
  selector: 'app-validation-error',
  templateUrl: './validation-error.component.html',
  styleUrls: ['./validation-error.component.css']
})
export class ValidationErrorComponent implements OnInit {
  @Input() operationResult!: OperationResult<any>;

  public get errorMessages(): string[] {
    const errors: string[] = [];
    if (this.operationResult && this.operationResult.hasErrors) {
      for (let errorCode of this.operationResult.errorCodes) {
        const errorCodeKey = `errorCodes.ERROR_${errorCode}`;
        this.translate.get(errorCodeKey).subscribe(errorMessage => {
          errors.push(errorMessage);
        })
      }
    }
    return errors;
  }

  constructor(private translate: TranslateService) { }

  ngOnInit(): void {
  }

}
