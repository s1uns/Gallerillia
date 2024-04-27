import styles from "./Auth.module.scss";
import { LockOutlined } from "@mui/icons-material";
import {
    Container,
    Box,
    Avatar,
    Typography,
    TextField,
    Grid,
} from "@mui/material";
import { FC, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { signIn } from "../../services/authApi";
import { toast } from "react-toastify";
import { Button } from "../../components/Button/Button";
import { IAuthProps } from "../../types/interfaces";

const Login: FC<IAuthProps> = (props: IAuthProps) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleLogin = () => {
        const response = signIn({ email: email, password: password });
        response
            .then((data) => {
                localStorage.setItem("userId", data.userId);
                localStorage.setItem("userRole", data.userRole);
                localStorage.setItem("bearer", data.bearer);
                props.setIsLogged(true);
                props.setCurrentPage("Home");
                navigate("/");
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data.message);
                } else {
                    toast.error("Couldn't log you in, try again.");
                }
            });
    };
    props.setCurrentPage("Login");

    return (
        <>
            <Container maxWidth="lg">
                <Box
                    className={styles["Auth-box"]}
                    sx={{
                        mt: 2,
                        display: "flex",
                        flexDirection: "column",
                        alignItems: "center",
                    }}
                >
                    <Avatar
                        sx={{
                            m: 1,
                            bgcolor: "rgb(56, 55, 54)",
                            height: "10rem",
                            width: "10rem",
                        }}
                        className={styles["Avatar"]}
                    >
                        <LockOutlined sx={{ fontSize: "5rem" }} />
                    </Avatar>
                    <Typography variant="h2">Login</Typography>
                    <Box sx={{ mt: 1 }} className={styles["Auth-box"]}>
                        <TextField
                            InputProps={{
                                className: styles["Text-field"],
                            }}
                            InputLabelProps={{
                                className: styles["Text-field--label"],
                            }}
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />

                        <TextField
                            InputProps={{
                                className: styles["Text-field"],
                            }}
                            InputLabelProps={{
                                className: styles["Text-field--label"],
                            }}
                            required
                            fullWidth
                            margin="normal"
                            id="password"
                            name="password"
                            label="Password"
                            type="password"
                            value={password}
                            onChange={(e) => {
                                setPassword(e.target.value);
                            }}
                        />

                        <Button
                            customStyles={styles["Button"]}
                            handleClick={handleLogin}
                            title="Login"
                        >
                            Login
                        </Button>
                        <Grid container justifyContent={"flex-end"}>
                            <Grid item>
                                <Link
                                    onClick={() => props.setCurrentPage("Sign Up")}
                                    to="/register"
                                    className={styles["Link"]}
                                >
                                    Don't have an account? Register
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
            </Container>
        </>
    );
};

export default Login;
