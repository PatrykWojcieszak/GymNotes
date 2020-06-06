import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private CONTROLLER: string = 'Chat/';
  private ADD_CONTACT: string = 'addContact';
  private GET_CONTACT_LIST: string = 'getContactList';
  private GET_CONTACT: string = 'getContact';
  private ADD_MESSAGE: string = 'addMessage';
  private GET_MESSAGE_LIST: string = 'getMessageList';
  
constructor(private API: APIService) { }

  public AddContact(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.ADD_CONTACT, null));
  }

  public AddMessage(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.ADD_MESSAGE, null));
  }
  
  public GetContactList(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_CONTACT_LIST, parameters));
  }
  
  public GetContact(parameters, query?: HttpParams) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_CONTACT, parameters), query);
  }
  
  public GetMessageList(parameters, query?: HttpParams) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_MESSAGE_LIST, parameters), query);
	}
}
