import axios from "axios";
import { ICredentials, ISignInResult } from "../types/interfaces";

const url = import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    ? import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    : "https://localhost:7189/api/";



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
