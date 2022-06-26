var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { filter } from 'rxjs/operators';
import { Alert, AlertType } from '../_models';
let AlertService = class AlertService {
    constructor() {
        this.subject = new Subject();
        this.defaultId = 'default-alert';
    }
    // enable subscribing to alerts observable
    onAlert(id = this.defaultId) {
        return this.subject.asObservable().pipe(filter(x => x && x.id === id));
    }
    // convenience methods
    success(message, options) {
        this.alert(new Alert(Object.assign(Object.assign({}, options), { type: AlertType.Success, message })));
    }
    error(message, options) {
        this.alert(new Alert(Object.assign(Object.assign({}, options), { type: AlertType.Error, message })));
    }
    info(message, options) {
        this.alert(new Alert(Object.assign(Object.assign({}, options), { type: AlertType.Info, message })));
    }
    warn(message, options) {
        this.alert(new Alert(Object.assign(Object.assign({}, options), { type: AlertType.Warning, message })));
    }
    // main alert method    
    alert(alert) {
        alert.id = alert.id || this.defaultId;
        this.subject.next(alert);
    }
    // clear alerts
    clear(id = this.defaultId) {
        this.subject.next(new Alert({ id }));
    }
};
AlertService = __decorate([
    Injectable({ providedIn: 'root' })
], AlertService);
export { AlertService };
//# sourceMappingURL=alert.service.js.map