import { HttpHeaders } from '@angular/common/http';

export abstract class AbstractHttpService {
    httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    textPlainHttpOptions = { headers: new HttpHeaders({ 'Content-Type': 'text/plain' }) };

    constructor(protected baseUrl: string) {
    }
}
