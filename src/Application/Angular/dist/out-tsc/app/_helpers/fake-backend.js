import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { HttpResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { of, throwError } from 'rxjs';
import { delay, materialize, dematerialize } from 'rxjs/operators';
// array in local storage for registered users
const usersKey = 'angular-10-registration-login-example-users';
let users = JSON.parse(localStorage.getItem(usersKey)) || [];
let FakeBackendInterceptor = class FakeBackendInterceptor {
    intercept(request, next) {
        const { url, method, headers, body } = request;
        return handleRoute();
        function handleRoute() {
            switch (true) {
                case url.endsWith('/Account/LoginPost') && method === 'POST':
                    return authenticate();
                case url.endsWith('/Account/RegisterPost') && method === 'POST':
                    return register();
                case url.endsWith('/users') && method === 'GET':
                    return getUsers();
                case url.match(/\/users\/\d+$/) && method === 'GET':
                    return getUserById();
                case url.match(/\/users\/\d+$/) && method === 'PUT':
                    return updateUser();
                case url.match(/\/users\/\d+$/) && method === 'DELETE':
                    return deleteUser();
                default:
                    // pass through any requests not handled above
                    return next.handle(request);
            }
        }
        // route functions
        function authenticate() {
            const { username, password } = body;
            const user = users.find(x => x.username === username && x.password === password);
            if (!user)
                return error('Почта или пароль введены неверно');
            return ok(Object.assign(Object.assign({}, basicDetails(user)), { token: 'fake-jwt-token' }));
        }
        function register() {
            const user = body;
            if (users.find(x => x.username === user.username)) {
                return error('Аккаунт с указанной электронной почтой уже существует');
            }
            user.id = users.length ? Math.max(...users.map(x => x.id)) + 1 : 1;
            users.push(user);
            localStorage.setItem(usersKey, JSON.stringify(users));
            return ok();
        }
        function getUsers() {
            if (!isLoggedIn())
                return unauthorized();
            return ok(users.map(x => basicDetails(x)));
        }
        function getUserById() {
            if (!isLoggedIn())
                return unauthorized();
            const user = users.find(x => x.id === idFromUrl());
            return ok(basicDetails(user));
        }
        function updateUser() {
            if (!isLoggedIn())
                return unauthorized();
            let params = body;
            let user = users.find(x => x.id === idFromUrl());
            // only update password if entered
            if (!params.password) {
                delete params.password;
            }
            // update and save user
            Object.assign(user, params);
            localStorage.setItem(usersKey, JSON.stringify(users));
            return ok();
        }
        function deleteUser() {
            if (!isLoggedIn())
                return unauthorized();
            users = users.filter(x => x.id !== idFromUrl());
            localStorage.setItem(usersKey, JSON.stringify(users));
            return ok();
        }
        // helper functions
        function ok(body) {
            return of(new HttpResponse({ status: 200, body }))
                .pipe(delay(500)); // delay observable to simulate server api call
        }
        function error(message) {
            return throwError({ error: { message } })
                .pipe(materialize(), delay(500), dematerialize()); // call materialize and dematerialize to ensure delay even if an error is thrown (https://github.com/Reactive-Extensions/RxJS/issues/648);
        }
        function unauthorized() {
            return throwError({ status: 401, error: { message: 'Unauthorized' } })
                .pipe(materialize(), delay(500), dematerialize());
        }
        function basicDetails(user) {
            const { id, username, firstName, lastName } = user;
            return { id, username, firstName, lastName };
        }
        function isLoggedIn() {
            return headers.get('Authorization') === 'Bearer fake-jwt-token';
        }
        function idFromUrl() {
            const urlParts = url.split('/');
            return parseInt(urlParts[urlParts.length - 1]);
        }
    }
};
FakeBackendInterceptor = __decorate([
    Injectable()
], FakeBackendInterceptor);
export { FakeBackendInterceptor };
export const fakeBackendProvider = {
    // use fake backend in place of Http service for backend-less development
    provide: HTTP_INTERCEPTORS,
    useClass: FakeBackendInterceptor,
    multi: true
};
//# sourceMappingURL=fake-backend.js.map