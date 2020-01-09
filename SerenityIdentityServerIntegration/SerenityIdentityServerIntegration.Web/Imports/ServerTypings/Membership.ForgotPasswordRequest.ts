namespace SerenityIdentityServerIntegration.Membership {
    export interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}

