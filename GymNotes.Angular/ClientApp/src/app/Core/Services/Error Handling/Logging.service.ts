import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class LoggingService {
	private httpClient: HttpClient;

	constructor(handler: HttpBackend) {
		this.httpClient = new HttpClient(handler);
	}

	logError(message: string, stack: string) {
		//const webHook = 'https://hooks.slack.com/services/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';
    console.warn(message);
    console.warn(stack);
		const slackMessage = {
			channel: '#angular',
			text: message
		};

		const headers = { 'Content-type': 'application/x-www-form-urlencoded' };

		//this.httpClient.post(webHook, JSON.stringify(slackMessage), { headers }).subscribe();

		console.log('LoggingService: ' + message);
	}
}
