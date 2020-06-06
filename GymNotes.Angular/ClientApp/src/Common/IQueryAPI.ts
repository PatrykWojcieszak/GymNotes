import { IPageQuery } from './IPageQuery';

export interface IQueryAPI extends IPageQuery {
    readonly search?: string;
    readonly [key: string]: string;
}
