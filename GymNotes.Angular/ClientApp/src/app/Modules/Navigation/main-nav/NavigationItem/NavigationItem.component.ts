import { Component, Inject, Input, OnInit } from "@angular/core";
import { RouterLinkActive } from "@angular/router";

@Component({
  selector: "app-NavigationItem",
  templateUrl: "./NavigationItem.component.html",
  styleUrls: ["./NavigationItem.component.scss"],
})
export class NavigationItemComponent implements OnInit {
  @Input() Title: string;
  @Input() Icon: string;

  constructor(
    @Inject(RouterLinkActive) public activeRouter: RouterLinkActive
  ) {}

  ngOnInit() {}
}
