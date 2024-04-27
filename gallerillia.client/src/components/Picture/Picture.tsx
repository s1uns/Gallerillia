import { FC } from "react";
import styles from "./Picture.module.scss";
import { VoteButton } from "../VoteButton/VoteButton";
import { PictureProps } from "../../types/interfaces";

export const Picture: FC<PictureProps> = (props: PictureProps) => {
    const userId = localStorage.getItem("userId");

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
                        isVoted={props.usersVote == "UPVOTED"}
                        isPositive={true}
                        votesCount={props.upVotesCount}
                    />
                    <VoteButton
                        isVoted={props.usersVote == "DOWNVOTED"}
                        isPositive={false}
                        votesCount={props.downVotesCount}
                    />
                </div>
            </div>
        </div>
    );
};
