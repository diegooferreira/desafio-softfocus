import { RequestResponseService } from "./../shared/http/RequestResponseService";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root",
})
export class ComunicacaoPerdaService {
    constructor(
        private http: HttpClient,
        private requestResponseService: RequestResponseService
    ) { }

    private baseUrl = environment.baseUrl;

    async getAll() {
        try {
            const response = await this.http
                .get(`${this.baseUrl}api/comunicacaoperda/getAll`)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async getByCpf(cpf:string) {
        try {
            const response = await this.http
                .get(`${this.baseUrl}api/comunicacaoperda/getByCpf/${cpf}`)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async getById(id:any) {
        try {
            const response = await this.http
                .get(`${this.baseUrl}api/comunicacaoperda/${id}`)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async postComunicacaoPerdaExistente(requestData:any) {
        try {
            const response = await this.http
                .post(`${this.baseUrl}api/comunicacaoperda/postComunicacaoPerdaExistente`, requestData)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async post(requestData:any) {
        try {
            const response = await this.http
                .post(`${this.baseUrl}api/comunicacaoperda`, requestData)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async put(id:any, requestData:any) {
        try {
            const response = await this.http
                .put(`${this.baseUrl}api/comunicacaoperda/${id}`, requestData)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }

    async delete(id:any) {
        try {
            const response = await this.http
                .delete(`${this.baseUrl}api/comunicacaoperda/${id}`)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }
}
