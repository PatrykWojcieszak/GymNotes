export class PaginatedList<T> {
  readonly pageIndex: number;
  readonly totalPages: number;
  readonly hasPreviousPage: boolean;
  readonly hasNextPage: boolean;
  readonly items: T[] = [];
}
