import { SharedModule } from "src/app/Shared/shared.module";
import { ToolsRoutingModule } from "./tools-routing.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { BMIComponent } from "./BMI/BMI.Component";
import { BodyFatComponent } from "./BodyFat/BodyFat.component";
import { ToolsMenuComponent } from "./ToolsMenu/ToolsMenu.component";
import { CalorieComponent } from "./Calorie/Calorie.component";
import { WilksComponent } from "./Wilks/Wilks.component";

@NgModule({
  declarations: [
    ToolsMenuComponent,
    BMIComponent,
    BodyFatComponent,
    CalorieComponent,
    WilksComponent,
  ],
  imports: [CommonModule, RouterModule, ToolsRoutingModule, SharedModule],
})
export class ToolsModule {}
