import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComunicacaoPerdaListComponent } from './comunicacao-perda-list/comunicacao-perda-list.component';
import { ComunicacaoPerdaNewComponent } from './comunicacao-perda-new/comunicacao-perda-new.component';
import { ComunicacaoPerdaEditComponent } from './comunicacao-perda-edit/comunicacao-perda-edit.component';
import { ComunicacaoPerdaViewComponent } from './comunicacao-perda-view/comunicacao-perda-view.component';
import { ComunicacaoPerdaRoutingModule } from './comunicacao-perda-routing.module';
import { ComunicacaoPerdaService } from './comunicacao-perda.service';
import { SharedModule } from '../shared/shared.module';

import { NgxMaskModule, IConfig } from 'ngx-mask';

const maskConfig: Partial<IConfig> = {
    validation: true,
};

@NgModule({
    declarations: [
        ComunicacaoPerdaListComponent,
        ComunicacaoPerdaNewComponent,
        ComunicacaoPerdaEditComponent,
        ComunicacaoPerdaViewComponent],
    imports: [
        CommonModule,
        ComunicacaoPerdaRoutingModule,
        SharedModule,
        HttpClientModule,
        NgxMaskModule.forRoot(maskConfig)
    ],
    providers: [ComunicacaoPerdaService]
})
export class ComunicacaoPerdaModule { }