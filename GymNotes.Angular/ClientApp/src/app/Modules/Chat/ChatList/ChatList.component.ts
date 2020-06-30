import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map, shareReplay } from 'rxjs/operators';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ActivatedRoute } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { timingSafeEqual } from 'crypto';

import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { ChatService } from 'src/app/Core/Services/Http/Chat/Chat.service';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';

@Component({
  selector: 'app-ChatList',
  templateUrl: './ChatList.component.html',
  styleUrls: ['./ChatList.component.css']
})
export class ChatListComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  public hubConnection: HubConnection;
  connectionId: any = '';
	receiverUsers: any[] = [];
	senderUser: any = {};
	receiverUserId: any = {};
  senderMessages: any[] = [];
  receiverMessages: any[] = [];
  _messages: any = [];

  msg: any = {
		text: ''
  };

	receipentId: string = '';
	receipent: any = {};
	receipentList: any[] = [];

	userFullName: string = '';

	constructor(
		private breakpointObserver: BreakpointObserver,
		private authentication: AuthenticationService,
		private route: ActivatedRoute,
		private chatService: ChatService,
		private userService: UserService) { }

  ngOnInit() {
		this.receipentId = this.route.snapshot.params.id;
		this.userFullName = this.authentication.UserFullName;

		if (this.route.snapshot.params.id != null) {
			this.getContact(this.route.snapshot.params.id);
		}

		let parameters: string[] = [this.authentication.UserId];
		this.chatService.GetContactList(parameters).subscribe(
			(res: any) => {
				this.receipentList = res;
			},
			(err) => {

			}
		);

    this.hubConnection = new HubConnectionBuilder().withUrl('/chat').build();

		this.hubConnection.on('Send', (msg) => {
			this.receiveMessage(msg);
		});

		this.hubConnection
			.start()
			.then(() => {
				console.log('Connection started');
				this.connectionId = this.hubConnection.invoke('GetConnectionId');
				console.warn(this.connectionId);
			})
			.catch((err) => {
				console.log(err);
			});
  }

  receiveMessage(msg) {
		if (this.receipent.id == msg.receiverId || this.receipent.id == msg.senderId) {
			this._messages.push(msg);
		}
  }

  send(msg) {
		this.hubConnection.invoke('Send', this.receipent.id, msg).catch(err => console.error(err));
	}

	sendMessage(event) {
		if (event.keyCode == 13 && this.receipent.id != null) {
			this.createMessage();

			this.msg = {};
		}
	}

	getContact(val: string){
		let parameters: string[] = [this.authentication.UserId];
		let model = {
			userId: this.authentication.UserId,
			receipentId: this.receipentId,
		};

		this.userService.GetUser(parameters).subscribe(
			(res: any) => {
				console.warn(res);
				this.receipentList.push(res);
				this.receipent = res;
			},
			(err) => {

			}
		);
	}

	createMessage() {
		const tmp = this.msg.text;
		const nd = new Date();

		let scopeMsg = {
			senderId: this.authentication.UserId,
			receiverId: this.receipent.id,
			content: this.msg.text,
			sendDate: nd,
			isSender: true
		};

		let sndMsg = {
			senderId: this.authentication.UserId,
			receiverId: this.receipent.id,
			content: this.msg.text,
			sendDate: nd,
			isSender: false,
		};

		this.saveMessage(scopeMsg);
		this.send(sndMsg);
  }

	selectRecipent(receipent: any){
		this.receipent = receipent;

		let parameters: string[] = [];
		let model = {
			userId: this.authentication.UserId,
			receipentId: this.receipent.id,
		};

		this.chatService.GetMessageList(parameters, new HttpParams({ fromObject: model })).subscribe(
			(res: any) => {
				this._messages = res;
				console.warn(res);
			},
			(err) => {

			}
		);
	}

  saveMessage(msg) {
		this._messages.push(msg);
		this.chatService.AddMessage(msg).subscribe(
			(res: any) => {
				console.warn(res);
			},
			(err) => {

			}
		);
	}
}
