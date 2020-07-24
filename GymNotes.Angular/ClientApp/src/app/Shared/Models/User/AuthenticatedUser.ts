export class AuthenticatedUser {
  id: string;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  alias: string;
  jwtToken?: string;
}
