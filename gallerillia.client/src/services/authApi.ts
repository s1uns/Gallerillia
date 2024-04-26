import axios from "axios";

const url = import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    ? import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    : "https://localhost:7189/api/";

export interface ICredentials {
    email: string;
    password: string;
}

export interface ISignInResult {
    userId: string;
    userRole: string;
    bearer: string;
}

export const signIn = async (credentials: ICredentials) => {
    const { data } = await axios.post<ISignInResult>(
        `${url}Account/sign-in`,
        credentials
    );

    return data;
};

export const signUp = async (credentials: ICredentials) => {
    const { data } = await axios.post<ISignInResult>(
        `${url}Account/sign-up`,
        credentials
    );

    return data;
};
