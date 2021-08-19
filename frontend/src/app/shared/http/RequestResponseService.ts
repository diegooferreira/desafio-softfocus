import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Router } from "@angular/router";
import { SweetAlertService } from "../services/SweetAlert.service";

@Injectable()
export class RequestResponseService {
    constructor(private swal: SweetAlertService) { }

    async handleError(err: any) {
        if (err) {
            let { error } = err;

            switch (err.status) {
                case 0:
                    this.swal.alertError(
                        "A aplicação está offline. Entre em contato com o suporte."
                    );
                    break;
                case 400:
                    this.swal.alertError(error.message);
                    break;
                case 500:
                    this.swal.alertError(error.message);
                    break;
                case 401:
                    this.swal.alertError(
                        "O usuário não tem autorização para utilizar o sistema"
                    );
                    break;
                case 403:
                    this.swal.alertError(
                        "O usuário não tem permissão para utilizar este recurso"
                    );
                    break;
                default:
                    break;
            }
        } else this.swal.alertError("Erro inesperado");
    }
}