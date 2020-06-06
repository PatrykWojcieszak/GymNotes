import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ToolsMenu',
  templateUrl: './ToolsMenu.component.html',
  styleUrls: ['./ToolsMenu.component.css']
})
export class ToolsMenuComponent implements OnInit {

  showComponent = 'general';
  
  constructor() { }

  ngOnInit() {
  }

  toogle(componentName: string) {
    this.showComponent = componentName;
  }
}
