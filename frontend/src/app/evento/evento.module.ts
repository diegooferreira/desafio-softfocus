import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { EventoService } from './evento.service';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        SharedModule,
        HttpClientModule
    ],
    providers: [EventoService]
})
export class EventoModule { }