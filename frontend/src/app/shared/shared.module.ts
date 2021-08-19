import { SweetAlertService } from './services/SweetAlert.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RequestResponseService } from './http/RequestResponseService';
import { LoaderInterceptor } from './http/Loader.interceptor';
import { CpfValidatorService } from './validators/CpfValidator.service';
import { CpfPipe } from './pipes/cpf-pipe';

@NgModule({
  declarations: [
    CpfPipe
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    RequestResponseService,
    SweetAlertService,
    CpfValidatorService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    CpfPipe
  ],
})
export class SharedModule { }