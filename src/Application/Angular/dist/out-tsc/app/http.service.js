import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
    }
    getData(link) {
        return this.http.get(link);
    }
    postData(link, body) {
        return this.http.post(link, body, { withCredentials: true });
    }
};
HttpService = __decorate([
    Injectable()
], HttpService);
export { HttpService };
//# sourceMappingURL=http.service.js.map