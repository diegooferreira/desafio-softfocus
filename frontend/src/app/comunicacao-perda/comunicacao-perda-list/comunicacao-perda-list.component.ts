import { SweetAlertService } from './../../shared/services/SweetAlert.service';
import { ComunicacaoPerdaService } from './../comunicacao-perda.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventoService } from 'src/app/evento/evento.service';
import { CpfValidatorService } from 'src/app/shared/validators/CpfValidator.service';

@Component({
  selector: 'app-comunicacao-perda-list',
  templateUrl: './comunicacao-perda-list.component.html',
  styleUrls: ['./comunicacao-perda-list.component.css']
})
export class ComunicacaoPerdaListComponent implements OnInit {

  comunicacoesPerda : any = [];
  cpfFiltro : string = '';

  constructor(private router: Router,
    private cpService: ComunicacaoPerdaService,
    private alertService: SweetAlertService,
    private cpfValidatorService: CpfValidatorService) { }

  async ngOnInit() {
    
    await this.pesquisarTodos();
  }

  async novoComunicado() {
    this.router.navigate(['comunicacao-perda/new']);
  }

  async pesquisar() {
    let cpfValido = await this.cpfValidatorService.cpfValido(this.cpfFiltro);

    if (!cpfValido) {
      await this.alertService.alertError(
        'O CPF informado é inválido'
      );

      return;
    }

    this.comunicacoesPerda = await this.cpService.getByCpf(this.cpfFiltro);
  }

  async pesquisarTodos() {
    this.comunicacoesPerda = await this.cpService.getAll();
  }

  async editar(id:any) {
    this.router.navigate(['comunicacao-perda/edit', id]);
  }

  async visualizar(id:any) {
    this.router.navigate(['comunicacao-perda/view', id]);
  }

  async deletar(id:any) {
    let result = await this.alertService.alertConfirm(
      'Deseja excluir permanentemente a comunicação de perda? Este processo é irreversível.'
    );

    if (result.isConfirmed) {
      await this.cpService.delete(id);

      await this.alertService.alertSuccess(
        'Comunicação de perda deletada com sucesso'
      );

      if((!this.cpfFiltro || !(this.cpfFiltro.length === 11))) {
        await this.pesquisarTodos();
      }
      else {
        await this.pesquisar();
      }
    }
  }
}
