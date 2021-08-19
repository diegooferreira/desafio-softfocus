import { SweetAlertService } from './../../shared/services/SweetAlert.service';
import { EventoService } from './../../evento/evento.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComunicacaoPerdaService } from '../comunicacao-perda.service';
import { CpfValidatorService } from 'src/app/shared/validators/CpfValidator.service';

@Component({
  selector: 'app-comunicacao-perda-new',
  templateUrl: './comunicacao-perda-new.component.html',
  styleUrls: ['./comunicacao-perda-new.component.css'],
})
export class ComunicacaoPerdaNewComponent implements OnInit {
  get f() {
    return this.form.controls;
  }

  public customPatterns = {
    '0': { pattern: new RegExp('^(-?d+(.d+)?),s*(-?d+(.d+)?)$') },
  };

  comunicadoSemelhanteExistente = false;

  submitted = false;

  form: FormGroup;

  eventos: any = [];

  constructor(
    private router: Router,
    private alertService: SweetAlertService,
    private fb: FormBuilder,
    private eventoService: EventoService,
    private cpService: ComunicacaoPerdaService,
    private cpfValidatorService : CpfValidatorService
  ) {
    this.form = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      cpf: ['', [Validators.required]],
      dataColheita: ['', [Validators.required]],
      tipoLavoura: ['', [Validators.required]],
      eventoOcorrido: ['', [Validators.required]],
      localizacaoLongitude: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$/
          ),
        ],
      ],
      localizacaoLatitude: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$/
          ),
        ],
      ],
    });
  }

  async ngOnInit() {
    this.eventos = await this.eventoService.getAll();
  }

  cancelar() {
    this.router.navigate(['comunicacao-perda/list']);
  }

  async submit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    let cpfValido = await this.cpfValidatorService.cpfValido(this.f.cpf.value);

    if (!cpfValido) {
      await this.alertService.alertError(
        'O CPF informado é inválido'
      );

      return;
    }

    let checkEventoRequest = {
      evento: this.f.eventoOcorrido.value,
      localizacaoLatitude: this.f.localizacaoLatitude.value,
      localizacaoLongitude: this.f.localizacaoLongitude.value,
      data: this.f.dataColheita.value,
    };

    let checkEventoResponse: any =
      await this.cpService.postComunicacaoPerdaExistente(checkEventoRequest);

    if (checkEventoResponse.length > 0) {
      let result = await this.alertService.alertConfirm(
        'Existe uma comunicação de perda com a mesma data, em um raio de 10Km. Deseja continuar?'
      );

      if (result.isConfirmed) {
        await this.salvar();
      }
    } else {
      await this.salvar();
    }
  }

  async salvar() {
    await this.cpService.post(this.form.value);

    await this.alertService.alertSuccess(
      'Comunicação de perda cadastrada com sucesso'
    );
    this.router.navigate(['comunicacao-perda/list']);
  }
}
