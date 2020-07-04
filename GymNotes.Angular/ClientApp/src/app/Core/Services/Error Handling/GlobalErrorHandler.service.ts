import { NotificationService } from './../Utility/Notification.service';
import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { LoggingService } from './Logging.service';
import { ErrorService } from './Error.service';

@Injectable({
	providedIn: 'root'
})
export class GlobalErrorHandlerService implements ErrorHandler {
	constructor(private injector: Injector) {}

	handleError(error) {
		//Injected manually because error handling is essential and it should be loaded first
		const errorService = this.injector.get(ErrorService);
		const logger = this.injector.get(LoggingService);
		const notifier = this.injector.get(NotificationService);

		let message;
		let stackTrace;

		if (error instanceof HttpErrorResponse) {
			// Server Error
			message = errorService.getServerMessage(error);
			stackTrace = errorService.getServerStack(error);
			notifier.showError(message);
		} else {
			// Client Error
			message = errorService.getClientMessage(error);
			stackTrace = errorService.getClientStack(error);
			notifier.showError(message);
		}

		// Always log errors
		logger.logError(message, stackTrace);

		console.error(error);
	}
}
