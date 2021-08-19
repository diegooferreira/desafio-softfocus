import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComunicacaoPerdaEditComponent } from './comunicacao-perda-edit/comunicacao-perda-edit.component';
import { ComunicacaoPerdaListComponent } from './comunicacao-perda-list/comunicacao-perda-list.component';
import { ComunicacaoPerdaNewComponent } from './comunicacao-perda-new/comunicacao-perda-new.component';
import { ComunicacaoPerdaViewComponent } from './comunicacao-perda-view/comunicacao-perda-view.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full'
  },
  {
    path: 'list',
    component: ComunicacaoPerdaListComponent
  },
  {
    path: 'new',
    component: ComunicacaoPerdaNewComponent
  },
  {
    path: 'edit/:id',
    component: ComunicacaoPerdaEditComponent
  },
  {
    path: 'view/:id',
    component: ComunicacaoPerdaViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComunicacaoPerdaRoutingModule { }