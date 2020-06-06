import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Settings',
  templateUrl: './Settings.component.html',
  styleUrls: ['./Settings.component.css']
})
export class SettingsComponent implements OnInit {

  showComponent = 'general';
  test: true;

  constructor(private router: Router, private route: ActivatedRoute,) { }

  ngOnInit() {

  }

  toogle(componentName: string) {
    this.showComponent = componentName;
  }
}
