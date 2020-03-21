import { HttpClient } from '@angular/common/http';
import { AbstractHttpService } from './abstract-http.service';

export abstract class AbstractRestService<T> extends AbstractHttpService {
    constructor(protected http: HttpClient, protected baseUrl: string) {
        super(baseUrl);
    }

    getAll(path: string = '') {
        return this.http.get<T[]>(`${this.baseUrl}${path}`);
    }

    getOne(id: number, path: string = '') {
        return this.http.get<T>(`${this.baseUrl}${path}/${id}`);
    }

    update(entity: any, path: string = '') {
        return this.http.put<any>(`${this.baseUrl}${path}/${entity.id}`, JSON.stringify(entity), this.httpOptions);
    }

    create(entity: any, path: string = '') {
        return this.http.post<any>(`${this.baseUrl}${path}`, JSON.stringify(entity), this.httpOptions);
    }

    delete(id: number, path: string = '') {
        return this.http.delete(`${this.baseUrl}${path}/${id}`);
    }
}
