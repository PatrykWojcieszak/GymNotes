import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Notifications',
  templateUrl: './Notifications.component.html',
  styleUrls: ['./Notifications.component.scss']
})
export class NotificationsComponent implements OnInit {

  showElement: string = '';
  constructor() { }

  ngOnInit() {
  }

  toggle(componentName: string) {
    this.showElement = componentName;
  }
}
