import { RequestResponseService } from "./../shared/http/RequestResponseService";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root",
})
export class EventoService {
    constructor(
        private http: HttpClient,
        private requestResponseService: RequestResponseService
    ) { }

    private baseUrl = environment.baseUrl;

    async getAll() {
        try {
            const response = await this.http
                .get(this.baseUrl + `api/evento/getAll`)
                .toPromise();

            return response;
        } catch (error) {
            this.requestResponseService.handleError(error);
            throw error;
        }
    }
}
