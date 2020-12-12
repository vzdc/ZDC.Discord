using System;
using System.ComponentModel.DataAnnotations;

namespace ZDC.Discord.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string ReverseName => $"{LastName}, {FirstName}";
        public string NameAndRating => $"{FullName} - {Rating}";
        public string NameAndCid => $"{FullName} - {Id}";
        public string Initials { get; set; }
        public string Email { get; set; }
        public ZdcRole ZdcRole { get; set; }
        public TrainingRole TrainingRole { get; set; }
        public VatsimRating Rating { get; set; }
        public Ground Ground { get; set; }
        public Tower Tower { get; set; }
        public MinorApp MinorApp { get; set; }
        public CHP CHP { get; set; }
        public MTV MTV { get; set; }
        public SHD SHD { get; set; }
        public Center Center { get; set; }
        public DateTime Joined { get; set; }
        public bool CanTrain { get; set; }
        public bool CanEvents { get; set; }
        public bool Visitor { get; set; }
        public string VisitorFrom { get; set; }
        public UserStatus Status { get; set; }
        public DateTime Updated { get; set; }

        /// <summary>
        ///     Gets if user has specified ZDC role
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <returns>True/False if they have the role</returns>
        public bool HasRole(ZdcRole role)
        {
            return ZdcRole == role;
        }

        /// <summary>
        ///     Gets if user has specified training role
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <returns>True/False if they have the role</returns>
        public bool HasTrainingRole(TrainingRole role)
        {
            return TrainingRole == role;
        }

        /// <summary>
        ///     Function to see if user is staff
        /// </summary>
        /// <returns>Bool if staff</returns>
        public bool IsStaff()
        {
            return ZdcRole != ZdcRole.None;
        }

        /// <summary>
        ///     Function to see if user is senior staff (or WM)
        /// </summary>
        /// <returns>Bool if senior staff</returns>
        public bool IsSrStaff()
        {
            return
                ZdcRole == ZdcRole.ATM ||
                ZdcRole == ZdcRole.DATM ||
                ZdcRole == ZdcRole.TA ||
                ZdcRole == ZdcRole.WM;
        }

        /// <summary>
        ///     Function to see if user is training staff
        /// </summary>
        /// <returns>Bool if training staff</returns>
        public bool IsTrainingStaff()
        {
            return TrainingRole != TrainingRole.None;
        }

        /// <summary>
        ///     Function to get string value of zdc role
        /// </summary>
        /// <returns>String of role</returns>
        public string StaffRoleString()
        {
            return ZdcRole switch
            {
                ZdcRole.ATM => "Air Traffic Manager",
                ZdcRole.DATM => "Deputy Air Traffic Manager",
                ZdcRole.TA => "Training Administrator",
                ZdcRole.ATA => "Assistant Training Administrator",
                ZdcRole.WM => "Web Master",
                ZdcRole.AWM => "Assistant Web Master",
                ZdcRole.EC => "Events Coordinator",
                ZdcRole.AEC => "Assistant Events Coordinator",
                ZdcRole.FE => "Facilities Engineer",
                ZdcRole.AFE => "Assistant Facilities Engineer",
                _ => "None"
            };
        }

        /// <summary>
        ///     Function to get string value of training role
        /// </summary>
        /// <returns>String of role</returns>
        public string TrainingRoleString()
        {
            return TrainingRole switch
            {
                TrainingRole.INS => "Instructor",
                TrainingRole.MTR => "Mentor",
                _ => "None"
            };
        }
    }

    public enum VatsimRating
    {
        NONE = -2,
        OBS = 1,
        S1,
        S2,
        S3,
        C1,
        C2,
        C3,
        I1,
        I2,
        I3,
        SUP
    }

    public enum ZdcRole
    {
        ATM,
        DATM,
        TA,
        ATA,
        WM,
        AWM,
        EC,
        AEC,
        FE,
        AFE,
        None
    }

    public enum TrainingRole
    {
        INS,
        MTR,
        None
    }

    public enum Ground
    {
        None,
        Solo,
        Minor,
        Certified
    }

    public enum Tower
    {
        None,
        Solo,
        Minor,
        Certified
    }

    public enum MinorApp
    {
        None,
        Solo,
        Certified
    }

    public enum MTV
    {
        None,
        Solo,
        Certified
    }

    public enum CHP
    {
        None,
        Solo,
        Certified
    }

    public enum SHD
    {
        None,
        Solo,
        Certified
    }

    public enum Center
    {
        None,
        Solo,
        Certified
    }

    public enum UserStatus
    {
        Removed = -1,
        Inactive,
        Active,
        LOA
    }
}