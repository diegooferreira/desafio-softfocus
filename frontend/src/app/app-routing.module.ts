import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const modulesRoutes: Routes = [
  {
    path: '',
    redirectTo: 'comunicacao-perda',
    pathMatch: 'full'
  },
  {
    path: 'comunicacao-perda',
    loadChildren: () =>
      import('src/app/comunicacao-perda/comunicacao-perda.module').then((m) => m.ComunicacaoPerdaModule),
  }
];

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children: modulesRoutes
  },
  {
    path: '**',
    redirectTo: '',
  },
]

@NgModule({
  imports: [
    [
      RouterModule.forRoot(routes, {
        anchorScrolling: 'enabled',
        scrollPositionRestoration: 'enabled',
        relativeLinkResolution: 'legacy',
        useHash: true
      }),
    ],
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { 

}
