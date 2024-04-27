import { FC } from "react";
import styles from "./Picture.module.scss";
import { VoteButton } from "../VoteButton/VoteButton";
import { IPictureProps } from "../../types/interfaces";
import { toast } from "react-toastify";
import { deletePicture, votePicture } from "../../services/api";
import { DeleteDialogWindow } from "../DialogWindow/DeleteDialogWindow";
import { TitleDialogWindow } from "../DialogWindow/TitleDialogWindow";
import { Button } from "../Button/Button";

export const Picture: FC<IPictureProps> = (props: IPictureProps) => {
    const userId = localStorage.getItem("userId");

    const onVote = (vote: string) => {
        if (!userId) {
            toast.warn("You should be authorized to vote the pictures.");
            return;
        }

        if (props.authorId == userId) {
            toast.warn("Cannot vote your picture.");
            return;
        }
        const response = votePicture(props.id, vote, props.usersVote);
        response
            .then((data) => {
                toast.success(data);
                props.onChange(true);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        props.onChange(false);
    };

    const onPictureDelete = () => {
        const response = deletePicture(props.id);
        response
            .then((data) => {
                toast.success(data);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        props.onChange(true);
    };

    return (
        <div className={styles["picture"]}>
            <div className={styles["container"]}>
                <div className={styles["image-container"]}>
                    <img
                        className={styles["image"]}
                        src={props.imgUrl}
                        alt="AlbumPicture"
                    />
                </div>
                <div className={styles["votes"]}>
                    <VoteButton
                        handleClick={() => onVote("UPVOTED")}
                        isVoted={props.usersVote == "UPVOTED"}
                        isPositive={true}
                        votesCount={props.upVotesCount}
                    />
                    <VoteButton
                        handleClick={() => onVote("DOWNVOTED")}
                        isVoted={props.usersVote == "DOWNVOTED"}
                        isPositive={false}
                        votesCount={props.downVotesCount}
                    />
                </div>
            </div>
            {props.canBeManaged ? (
                <div className={styles["manage-btns"]}>
                    <DeleteDialogWindow
                        entityName="picture"
                        handleAgree={onPictureDelete}
                        render={(handleClick) => (
                            <Button
                                customStyles={styles["delete-btn"]}
                                title={"Delete picture"}
                                handleClick={handleClick}
                            >
                                Delete
                            </Button>
                        )}
                    ></DeleteDialogWindow>
                </div>
            ) : null}
        </div>
    );
};
