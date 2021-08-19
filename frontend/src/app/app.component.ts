import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Desafio - Softfocus';

  constructor() {
    // show the spinner
    //spinner.show();
    //////////////
    // HTTP requests performed between show && hide won't have any side effect on the spinner.
    /////////////
    // hide the spinner
    //spinner.hide();
  }
}
