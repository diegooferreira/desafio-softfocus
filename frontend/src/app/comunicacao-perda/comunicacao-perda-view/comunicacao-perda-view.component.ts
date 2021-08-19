import { SweetAlertService } from './../../shared/services/SweetAlert.service';
import { EventoService } from './../../evento/evento.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComunicacaoPerdaService } from '../comunicacao-perda.service';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-comunicacao-perda-view',
  templateUrl: './comunicacao-perda-view.component.html',
  styleUrls: ['./comunicacao-perda-view.component.css'],
})
export class ComunicacaoPerdaViewComponent implements OnInit {
  get f() {
    return this.form.controls;
  }

  form: FormGroup;
  eventos: any = [];
  id: number = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private alertService: SweetAlertService,
    private fb: FormBuilder,
    private eventoService: EventoService,
    private cpService: ComunicacaoPerdaService
  ) {
    this.form = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      cpf: ['', [Validators.required]],
      dataColheita: ['', [Validators.required]],
      tipoLavoura: ['', [Validators.required]],
      eventoOcorrido: ['', [Validators.required]],
      localizacaoLongitude: ['', []],
      localizacaoLatitude: ['', []],
    });
  }

  async ngOnInit() {
    try {
      this.id = Number(this.route.snapshot.paramMap.get('id'));
      this.eventos = await this.eventoService.getAll();

      var cpData: any = await this.cpService.getById(this.id);

      this.form.setValue({
        nome: cpData.nome,
        email: cpData.email,
        cpf: cpData.cpf,
        dataColheita: formatDate(cpData.dataColheita, 'yyyy-MM-dd', 'pt-BR'),
        tipoLavoura: cpData.tipoLavoura,
        eventoOcorrido: cpData.eventoOcorrido,
        localizacaoLongitude: cpData.localizacaoLongitude,
        localizacaoLatitude: cpData.localizacaoLatitude,
      });
    } catch {
      await this.alertService.alertError(
        'Erro ao obter a comunicação de perda'
      );
      this.router.navigate(['comunicacao-perda/list']);
    }
  }

  voltar() {
    this.router.navigate(['comunicacao-perda/list']);
  }
}
