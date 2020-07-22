import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { AuthGuard } from './Auth/auth.guard';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';
import { NotificationListComponent } from './Modules/Notifications/NotificationList/NotificationList.component';

const routes: Routes = [
	{
		path: '',
		component: HomeLayoutComponent,
		canActivate: [ AuthGuard ],
		children: [
			{
				path: 'tools',
				loadChildren: () => import('./Modules/Tools/tools.module').then((m) => m.ToolsModule)
			},
			{
				path: 'settings',
				loadChildren: () => import('./Modules/Settings/settings.module').then((m) => m.SettingsModule)
			},
			{
				path: 'calendar',
				loadChildren: () =>
					import('./Modules/Training History/trainingHistory.module').then((m) => m.TrainingHistoryModule)
			},
			{
				path: 'training-list',
				loadChildren: () =>
					import('./Modules/Training Plan/trainingPlan.module').then((m) => m.TrainingPlanModule)
			},
			{
				path: 'chat',
				loadChildren: () => import('./Modules/Chat/chat.module').then((m) => m.ChatModule)
			},
			{
				path: 'userList',
				loadChildren: () => import('./Modules/User/user.module').then((m) => m.UserModule)
			},
			{
				path: 'statistics',
				loadChildren: () => import('./Modules/Statistics/statistics.module').then((m) => m.StatisticsModule)
			},
			{ path: 'notifications', component: NotificationListComponent, canActivate: [ AuthGuard ] }
		]
	},
	{
		path: '',
		component: LoginLayoutComponent,
		children: [
			{
				path: 'user',
				loadChildren: () => import('./Modules/Signing/signing.module').then((m) => m.SigningModule)
			}
		]
	},
	//{ path: '**', redirectTo: '' }
];

@NgModule({
	imports: [ RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }) ],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}
