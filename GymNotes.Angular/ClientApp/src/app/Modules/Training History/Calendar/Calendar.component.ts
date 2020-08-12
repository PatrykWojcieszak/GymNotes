import { ConfirmationDialogService } from 'src/app/Core/Services/Utility/ConfirmationDialog.service';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { TrainingHistoryService } from './../../../Core/Services/Http/TrainingHistory/TrainingHistory.service';
import { AddFinishedWorkoutComponent } from './../AddFinishedWorkout/AddFinishedWorkout.component';
import {Component,ChangeDetectionStrategy,ViewChild,TemplateRef, OnInit} from '@angular/core';
import {startOfDay,endOfDay,subDays,addDays,endOfMonth,isSameDay,isSameMonth,addHours,} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {CalendarEvent,CalendarEventAction,CalendarEventTimesChangedEvent,CalendarView,} from 'angular-calendar';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'mwl-demo-component',
  styleUrls: ['Calendar.component.scss'],
  templateUrl: 'Calendar.component.html',
})
// tslint:disable-next-line: component-class-suffix
export class Calendar implements OnInit {
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  actions: CalendarEventAction[] = [
    {
      label: '<i class="fa fa-fw fa-pencil"></i>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      },
    },
    {
      label: '<i class="fa fa-fw fa-times"></i>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        //this.events = this.events.filter((iEvent) => iEvent !== event);
        //this.handleEvent('Deleted', event);
        this.deleteWorkout(event);
      },
    },
  ];

  refresh: Subject<any> = new Subject();

  events: CalendarEvent[] = [];

  activeDayIsOpen: boolean = true;

  constructor(
    private modal: NgbModal,
    private matDialog: MatDialog,
    private trainingHistory: TrainingHistoryService,
    private authentication: AuthenticationService,
    private confirmationDialog: ConfirmationDialogService) {}

  ngOnInit(): void {
    const parameters = [this.authentication.UserId];

    this.trainingHistory.GetWorkoutHistory(parameters).subscribe(x => this.loadData(x));
  }

  loadData(data){
    for (let i = 0; i < data.length; i++) {
			this.events = [
				...this.events,
				{
					id: data[i].id,
					title: data[i].workoutName,
					start: startOfDay(new Date(data[i].date)),
					end: endOfDay(new Date(data[i].date)),
					color: colors.red,
					draggable: true,
					actions: this.actions,
					resizable: {
						beforeStart: true,
						afterEnd: true
					}
				}
			];
		}
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    this.modal.open(this.modalContent, { size: 'lg' });
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.events = this.events.filter((event) => event !== eventToDelete);
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  addTraining() {
    const dialogConfig = new MatDialogConfig();
    this.matDialog.open(AddFinishedWorkoutComponent, {
      width: '50%',
    });
    this.matDialog._afterAllClosed.subscribe((x) => {});
  }

  deleteWorkout(event){
    this.confirmationDialog
			.confirm(
				'Please confirm..',
				'Do you really want to delete this workout ?'
			)
			.then((confirmed) => {
        const parameters = [event.id];
        this.trainingHistory.DeleteWorkout(parameters).subscribe(x => console.warn(x));
        this.events = this.events.filter((temp) => temp !== event);
			})
			.catch(() =>
				console.log(
					'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
				)
			)
  }
}
