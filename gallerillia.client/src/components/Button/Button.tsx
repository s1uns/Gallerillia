import { ReactNode, FC } from "react";
import styles from "./Button.module.scss";
import { IButtonProps } from "../../types/interfaces";

export const Button: FC<IButtonProps> = (props: IButtonProps) => {
    return (
        <button
            onClick={props?.handleClick}
            className={`${props?.customStyles ? props.customStyles : ""} ${
                styles["button"]
            }`}
            type={props.type}
            title={props.title}
            disabled={props?.disabled}
        >
            {props.children}
        </button>
    );
};
