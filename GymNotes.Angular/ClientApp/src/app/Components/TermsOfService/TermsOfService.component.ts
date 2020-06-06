import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-TermsOfService',
  templateUrl: './TermsOfService.component.html',
  styleUrls: ['./TermsOfService.component.css']
})
export class TermsOfServiceComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  ScrollToTop(){
    window.scroll(0,0);
  }

}
