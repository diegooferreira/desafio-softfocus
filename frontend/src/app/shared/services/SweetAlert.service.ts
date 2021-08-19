import { style } from '@angular/animations';
import { Injectable } from '@angular/core';
import { SweetAlert2LoaderService } from '@sweetalert2/ngx-sweetalert2';

import Swal, { SweetAlertOptions } from 'sweetalert2';

@Injectable()
export class SweetAlertService {
  constructor() {}

  async alertError(text?: string, title?: string) {
    return Swal.fire({
      icon: 'error',
      title: title ?? 'Erro',
      text: text ?? 'Ocorreu um erro durante o processamento.',
      showConfirmButton: true,
      allowEscapeKey: false,
      allowOutsideClick: false,
    });
  }

  async alertSuccess(text?: string, title?: string) {
    return Swal.fire({
      icon: 'success',
      title: title ?? 'Sucesso',
      text: text ?? 'A operação foi realizada com sucesso.',
      showConfirmButton: true,
    });
  }

  async alertWarning(text?: string, title?: string) {
    return Swal.fire({
      icon: 'warning',
      title: title ?? 'Atenção',
      text: text ?? 'Atenção.',
      showConfirmButton: true,
    });
  }

  async alertInfo(text?: string, title?: string) {
    return Swal.fire({
      icon: 'info',
      title: title ?? 'Informação',
      text: text ?? 'Informação.',
      showConfirmButton: true,
    });
  }

  async alertConfirm(text?: string, title?: string, textConfirm?: string, textCancel?: string) {
    return Swal.fire({
      icon: 'warning',
      title: title ?? 'Confirmação',
      text: text ?? 'Você deseja realmente realizar esta operação?',
      showConfirmButton: true,
      showCancelButton: true,
      confirmButtonText: textConfirm ?? `Sim`,
      cancelButtonText: textCancel ?? `Não`,
      cancelButtonColor: '#d33'
    });
  }

  Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    width: 500,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer);
      toast.addEventListener('mouseleave', Swal.resumeTimer);
    },
    customClass: {
      title: 'titulo-custom'
    }
  });

  async toastError(text?: string) {
    return this.Toast.fire({
      icon: 'error',
      title: text ?? 'Ocorreu um erro durante o processamento.',
    });
  }

  async toastSuccess(text?: string) {
    return this.Toast.fire({
      icon: 'success',
      title: text ?? 'A operação foi realizada com sucesso.',
    });
  }

  async toastWarning(text?: string) {
    return this.Toast.fire({
      icon: 'warning',
      title: text ?? 'Atenção.',
    });
  }

  async toastInfo(text?: string) {
    return this.Toast.fire({
      icon: 'info',
      title: text ?? 'Informação.',
    });
  }
}